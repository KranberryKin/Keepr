<template>
   <form class="VaultForm text-center" @submit.prevent="CreateVault()">
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
    <button class="btn btn-outline-success">Create Vault</button>
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
      user: computed(() => AppState.account),
      CreateVault(){
        vault.value.creatorId = user.creatorId
        vaultsService.CreateVault(vault.value)
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>