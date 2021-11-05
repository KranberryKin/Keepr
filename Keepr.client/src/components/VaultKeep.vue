<template>
<div class="col-3 mt-2">
  <div :data-bs-target="'#keep-modal-' + keep.id" data-bs-toggle="modal">
    <img :src="keep.img" class="img-fluid keepImg" alt="">
    <h6 class="text-center">{{keep.name}}</h6>
  </div>
  <Model :id="'keep-modal-' + keep.id">
    <template #modal-body>
      <div class="row">
        <div class="col-12">
          <button type="button" class="btn-close close" data-bs-dismiss="modal" aria-label="Close"></button>
          <div class="row">
            <div class="col-6">
              <img :src="keep.img" class="img-fluid rounded" alt="">
            </div>
            <div class="col-6 text-center">
              <div class="row justify-content-center">
                <div class="col-3 d-flex flex-row align-items-center">
                  <i class="mdi mdi-eye mdi-24px px-1"></i>{{keep.views}}
                </div>
                <div class="col-3 d-flex flex-row align-items-center">
                  <i class="mdi mdi-alpha-k-box-outline mdi-24px pt-0 px-1"></i>{{keep.keeps}}
                </div>
                <div class="col-3 d-flex flex-row align-items-center">
                  <i class="mdi mdi-share-variant mdi-24px pt-0 px-1"></i>{{keep.shares}}
                </div>
              </div>
              <div class="row text-center">
                <h4 class="pt-2">{{keep.name}}</h4>
              </div>
              <div class="row text-center">
                <div class="border-bottom py-3">{{keep.description}}</div>
              </div>
              <div class="row mt-2 align-items-center">
                  <div class="col-4">
                    <button class="btn btn-outline-info" type="dropdown">Vaults</button>
                  </div>
                  <div class="col-3">
                    <i class="mdi mdi-trash-can mdi-36px action" :data-bs-target="'#keep-modal-' + keep.id" data-bs-toggle="modal" :class="keep.creatorId === user.id ? '':'visually-hidden'" @click="DeleteKeep(keep.vaultKeepId)"></i>
                  </div>
                  <div class="col-5 d-flex flex-row">
                    <router-link :to="{name:'Profile', params:{profileId : keep.creatorId}}" >
                      <img :src="keep.creator.picture" class="rounded icon mx-1 action" alt="" :data-bs-target="'#keep-modal-' + keep.id" data-bs-toggle="modal">
                    </router-link>
                    <p class="break">{{keep.creator.name}}</p>
                  </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </template>
  </Model>
</div>
</template>


<script>
import { computed } from "@vue/reactivity"
import { KeepModel } from "../models/KeepModel"
import { AppState } from "../AppState"
import Pop from "../utils/Pop"
import { vaultKeepsService } from "../services/VaultKeepsService"
export default {
  props:{
    keep:{
      type: KeepModel,
      required: true
    }
  },
  setup(props){
    const keepImg = computed(() => `url(${props.keep.img})`)
    return {
      keepImg,
      user: computed(() => AppState.account),
      async DeleteKeep(keepId){
        if (await Pop.confirm()){
          vaultKeepsService.DeleteVaultKeep(keepId)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.Keep{
  background-image: v-bind(keepImg);
  // background-size: cover;
  background-repeat: no-repeat;
  height: fit-content;
}
.close{
  float: right;
}
.icon{
  height: 36px;
}
.break{
  word-break: break-all;
}
.keepImg{
  height: 100%;
  border-radius: 10%;
}
</style>