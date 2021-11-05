<template>
  <div class="home masonry-with-columns">
    <Keep v-for="k in keeps" :key="k.id" :keep="k"/>
  </div>
</template>

<script>
import { computed, onMounted } from "@vue/runtime-core"
import { keepsService } from "../services/KeepsService"
import { AppState } from "../AppState"
import { profilesService } from "../services/ProfilesService"
export default {
  name: 'Home',
  setup(){
    onMounted( async () => {
      await profilesService.GetVaultsByProfileId(AppState.account.id)
      await keepsService.GetKeeps()

    })
    const keeps = computed(() => AppState.keeps)
    return{
      keeps,
    }
  }
}
</script>

<style scoped lang="scss">
.masonry-with-columns {
  columns: 4 200px;
  column-gap: 1rem;
  div {
    width: 150px;
    color: white;
    margin: 0 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
  }
}
// .grid {
//   display: grid;
//   grid-gap: 10px;
//   grid-template-columns: repeat(auto-fill, minmax(250px,1fr));
//   grid-auto-rows: 20px;
// }
</style>
