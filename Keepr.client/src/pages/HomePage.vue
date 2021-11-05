<template>
  <div class="home row">
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
.masonry-with-flex {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  div {
    color: white;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
  } 
  @for $i from 1 through 36 { 
    div:nth-child(#{$i}) {
      $h: (random(400) + 100) + px;
      height: $h;
      line-height: $h;
    }
  }
}
// .grid {
//   display: grid;
//   grid-gap: 10px;
//   grid-template-columns: repeat(auto-fill, minmax(250px,1fr));
//   grid-auto-rows: 20px;
// }
</style>
