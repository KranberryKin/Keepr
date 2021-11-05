import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultKeepsService{
  async CreateVaultKeeps(data){
    const res = await api.post('api/vaultkeeps', data)
    logger.log("create vaultkeeps res", res.data)
  }
}

export const vaultKeepsService = new VaultKeepsService()