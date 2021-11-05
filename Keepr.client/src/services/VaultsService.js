import { AppState } from "../AppState"
import { KeepModel } from "../models/KeepModel"
import { VaultModel } from "../models/VaultModel"
import { router } from "../router"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { keepsService } from "./KeepsService"

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
async CreateVault(vaultData){
  const res = await api.post('api/vaults', vaultData)
  logger.log("Create vault res", res)
  AppState.vaults = [new VaultModel(res.data), ...AppState.vaults]
}
async EditVault(vaultData){
  const res = await api.put('api/vaults/' + vaultData.id, vaultData)
  logger.log("Edit vault res", res)
  let vaultIndex = AppState.vaults.findIndex(v => v.id === vaultData.id)
  AppState.vaults.splice(vaultIndex, 1, new VaultModel(res.data))
}
async DeleteVault(vaultId){
  const res = await api.delete('api/vaults/' + vaultId)
  logger.log("Delete vault res", res)
  let vaultIndex = AppState.vaults.findIndex(v => v.id === vaultId)
  AppState.vaults.splice(vaultIndex, 1)
}
async GetVaultKeeps(vaultId){
  AppState.keeps = []
  const res = await api.get(`api/vaults/${vaultId}/keeps`)
  logger.log("Get vaul keeps res", res)
  AppState.keeps = res.data.map(vk => new KeepModel(vk))
}
}

export const vaultsService = new VaultsService()