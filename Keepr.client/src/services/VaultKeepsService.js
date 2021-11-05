import { AppState } from "../AppState"
import { router } from "../router"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultKeepsService{
  async CreateVaultKeeps(data){
    const res = await api.post('api/vaultkeeps', data)
    logger.log("create vaultkeeps res", res.data)
  }
  async DeleteVaultKeep(keepId){
    const res = await api.delete("api/vaultkeeps/" + keepId)
    logger.log("deleted vaultkeep res", res)
    let keepIndex = AppState.keeps.findIndex(k => k.vaultKeepId === keepId)
    AppState.keeps.splice(keepIndex, 1)
  }
}

export const vaultKeepsService = new VaultKeepsService()