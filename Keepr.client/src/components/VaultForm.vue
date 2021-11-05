<template>
   <form class="VaultForm text-center" @submit.prevent="CreateVault(profile.id)">
     <h6>Create a Vault!</h6>
    <div class="form-group">
      <label for="name">Name :</label><br>
      <input type="text" name="name" v-model="vault.name" required>
    </div>
    <div class="form-group">
      <label for="description">Description :</label><br>
      <input type="text" name="description" v-model="vault.description" required>
    </div>
    <div class="form-group">
      <label for="isPrivate">Want it Private?</label>
      <input type="checkbox" name="isPrivate" v-model="vault.isPrivate">
    </div>
    <button class="btn btn-outline-success" :data-bs-target="'#vault-modal-' + profile.id" data-bs-toggle="modal">Create Vault</button>
  </form>
</template>


<script>
import { computed, ref } from "@vue/reactivity"
import { AppState } from "../AppState"
import { vaultsService } from "../services/VaultsService"
export default {
  setup(){
    const vault = ref({})
    return {
      vault,
      profile: computed(() => AppState.account),
      CreateVault(){
        vaultsService.CreateVault(vault.value)
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>