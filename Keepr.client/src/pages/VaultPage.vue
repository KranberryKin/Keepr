<template>
  <div class="Vault">
    <div class="row mt-4">
      <div class="col-6 ps-5">
        <h4>{{ activeVault.name }}</h4>
        <h6>Keeps : {{ keepsCount }}</h6>
      </div>
      <div class="col-6 text-end pe-5" :class="activeVault.creatorId === user.id ? '':'visually-hidden'">
        <button class="btn btn-outline-danger" @click="DeleteVault(activeVault.id)">Delete Vault</button>
      </div>
    </div>
      <h4 class="ps-5">Vault Keeps</h4>
    <div class="row" v-if="keeps.length != 0">
      <VaultKeep v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
    <div class="row ps-5" v-else>
      <h6>No Keeps Yet...</h6>
    </div>
  </div>
</template>


<script>
import { computed, onBeforeMount } from "@vue/runtime-core"
import { useRoute } from "vue-router"
import { vaultsService } from "../services/VaultsService"
import { AppState } from "../AppState"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { router } from "../router"
export default {
  setup(){
    const route = useRoute()
    onBeforeMount(async () => {
      try {
        await vaultsService.GetVaultById(route.params.vaultId, AppState.account.id)
        await vaultsService.GetVaultKeeps(route.params.vaultId)
      } catch (error) {
        if(error){
          router.push({name: 'Home'})
          return new Error('You cant go here!')
        }
      }
      
    })
    return {
      activeVault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps),
      keepsCount: computed(() => AppState.keeps.length),
      user: computed(() => AppState.account),
      DeleteVault(vaultId){
        if (Pop.confirm()){
          vaultsService.DeleteVault(vaultId)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>