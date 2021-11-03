import { AppState } from "../AppState"
import { VaultModel } from "../models/VaultModel"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultsService{
async GetVaults(){
  AppState.vaults = []
  const res = await api.get('api/vaults')
  logger.log("Get all vaults res", res)
  AppState.vaults = res.data.map(v => new VaultModel(v))
}
async GetVaultById(vaultId){
  const res = await api.get('api/vaults/' + vaultId)
  logger.log("get vault by id res", res)
  AppState.activeVault = new VaultModel(res.data)
}
}

export const vaultsService = new VaultsService()