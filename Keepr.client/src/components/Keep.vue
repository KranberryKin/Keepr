<template>
  <div class="Keep col-3">
    <h6>Hello from Keep</h6>
  </div>
</template>


<script>
import { KeepModel } from "../models/KeepModel"
export default {
  props:{
    keep:{
      type: KeepModel,
      required: true
    }
  },
  setup(props){
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>