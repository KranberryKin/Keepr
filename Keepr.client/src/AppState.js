import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  /**@type {import('./models/KeepModel').KeepModel[]} */
  keeps: [],
  /**@type {import('./models/KeepModel').KeepModel} */
  activeKeep: {},
  vaults: [],
  activeVault: {},
  activeProfile: {}
})
