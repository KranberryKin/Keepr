<template>
  <div class="Vault col-lg-2 col-md-3 col-5 my-3 mx-1 rounded">
    <router-link :to="{name: 'Vault', params:{vaultId: vault.id}}">
      <h6>{{vault.name}}</h6>
    </router-link>
  </div>
</template>


<script>
import { computed } from "@vue/reactivity"
import { VaultModel } from "../models/VaultModel"
export default {
  props:{
    vault:{
      type: VaultModel,
      default: () => new VaultModel()
    }
  },
  setup(props){
    return {
      vaultImg: computed(() => `url(https://images.unsplash.com/photo-1609358905581-e5381612486e?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=411&q=80)`)
    }
  }
}
</script>


<style lang="scss" scoped>
.Vault{
  background-image: v-bind(vaultImg);
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  min-height: 12rem;
}
</style>