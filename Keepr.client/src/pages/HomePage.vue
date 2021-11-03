<template>
  <div class="home row d-flex">
    <Keep v-for="k in keeps" :key="k.id" :keep="k"/>
  </div>
</template>

<script>
import { computed, onMounted } from "@vue/runtime-core"
import { keepsService } from "../services/KeepsService"
import { AppState } from "../AppState"
export default {
  name: 'Home',
  setup(){
    onMounted( async () => {
      await keepsService.GetKeeps()
    })
    const keeps = computed(() => AppState.keeps)
    return{
      keeps
    }
  }
}
</script>

<style scoped lang="scss">

</style>
