<template>
  <form class="KeepForm text-center" @submit.prevent="CreateKeep()">
    <h6>Create a Keep!</h6>
    <div class="form-group">
      <label for="name">Name :</label><br>
      <input type="text" name="name" v-model="keep.name" required>
    </div>
    <div class="form-group">
      <label for="img">Image Url :</label><br>
      <input type="text" name="img" v-model="keep.img" required>
    </div>
    <div class="form-group">
      <label for="description">Description :</label><br>
      <textarea  name="description" v-model="keep.description" required/>
    </div>
<button class="btn btn-outline-success mt-3" type="submit"  :data-bs-target="'#keep-modal-' + profile.id" data-bs-toggle="modal">Create Keep</button>
  </form>
</template>


<script>
import { computed, ref } from "@vue/reactivity"
import { AppState } from "../AppState"
import { keepsService } from "../services/KeepsService"
export default {
  setup(){
    const keep = ref({})
    return {
      keep,
      profile: computed(() => AppState.account),
      CreateKeep(){
        keep.value.creatorId = AppState.account.id
        keepsService.CreateKeep(keep.value)
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>