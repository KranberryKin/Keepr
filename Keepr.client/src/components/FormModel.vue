<template>
  <!-- Modal -->
  <div class="modal fade"
       id="modelId"
       tabindex="-1"
       role="dialog"
       aria-labelledby="modelTitleId"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <!-- SLOT -->
          <slot name="modal-body"></slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: '',
  setup() {
    return {}
  }
}
</script>

<style lang="scss" scoped>
</style>