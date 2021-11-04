<template>
  <div class="Profile">
    <div class="row">
      <div class="col col-lg-2 mt-4 ps-5">
        <img :src="profile.picture" alt="" class="profImg">
      </div>
      <div class="col col-lg-10 mt-4">
        <div class="row"><h1>{{profile.name}}</h1></div>
        <div class="row"><h6>Vaults: {{vaultCount}}</h6></div>
        <div class="row"><h6>Keeps: {{keepsCount}}</h6></div>
      </div>
    </div>
    <div class="row mt-3">
      <h1 class="ps-5">Vaults</h1>
       
    </div>
    <div class="row mt-3">
      <h1 class="ps-5">Keeps</h1>
      <Keep v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>


<script>
import { computed, onBeforeMount } from "@vue/runtime-core"
import {profilesService} from "../services/ProfilesService"
import { useRoute } from "vue-router"
import { AppState } from "../AppState"
export default {
  setup(){
    const route = useRoute()
    onBeforeMount(async () => {
      await profilesService.GetProfile(route.params.profileId)
      await profilesService.GetVaultsByProfileId(route.params.profileId)
      await profilesService.GetKeepsByProfileId(route.params.profileId)
    })
    return {
      vaultCount: computed(() => AppState.vaults.length),
      keepsCount: computed(() => AppState.keeps.length),
      profile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    }
  }
}
</script>


<style lang="scss" scoped>
.profImg{
  max-width: 150px;
  border-radius: 15%;
}
</style>