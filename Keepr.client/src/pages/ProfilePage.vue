<template>
  <div class="Profile">
    <div class="row">
      <div class="col-4 col-lg-2 mt-4 ps-54 col-md-3">
        <img :src="profile.picture" alt="" class="profImg">
      </div>
      <div class="col-8 col-lg-10 mt-4 col-md-9">
        <div class="row"><h1>{{profile.name}}</h1></div>
        <div class="row"><h6>Vaults: {{vaultCount}}</h6></div>
        <div class="row"><h6>Keeps: {{keepsCount}}</h6></div>
      </div>
    </div>
    <div class="row mt-3 d-flex flex-row">
      <div class="col-12">
        <div class="row align-items-center">
          <div class="col-lg-2 col-4 col-md-3">
          <h1 class="ps-5">Vaults</h1>
          </div>
          <div class="col-lg-10 col-8 col-md-9 flex-start" :class="profile.id === user.id ? '':'visually-hidden'">
          <i class="mdi mdi-plus action" :data-bs-target="'#vault-modal-' + profile.id" data-bs-toggle="modal"></i>
          </div>
        </div>
      </div>
      <div class="col-12">
        <div class="row justify-content-around">
           <Vault v-for="v in vaults" :key="v.id" :vault="v" />
        </div>
      </div>
    </div>
    <div class="row align-items-center">
      <div class="col-lg-2 col-4 col-md-3">
         <h1 class="ps-5">Keeps</h1>
      </div>
      <div class="col-lg-10 col-8 col-md-9 flex-start" :class="profile.id === user.id ? '':'visually-hidden'" >
        <i class="mdi mdi-plus action"  :data-bs-target="'#keep-modal-' + profile.id" data-bs-toggle="modal"></i>
      </div>
    </div>
    <div class="row mt-3" data-masonry='{"percentPosition": true }'>
      <Keep v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
    <Model :id="'keep-modal-' + profile.id">
      <template #modal-body>
        <KeepForm />
      </template>
    </Model>
    <Model :id="'vault-modal-' + profile.id">
      <template #modal-body>
        <VaultForm />
      </template>
    </Model>
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
      vaults: computed(() => AppState.vaults),
      user: computed(() => AppState.account)
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