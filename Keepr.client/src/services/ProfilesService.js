import { AppState } from "../AppState"
import { KeepModel } from "../models/KeepModel"
import { ProfileModel } from "../models/ProfileModel"
import { VaultModel } from "../models/VaultModel"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ProfilesService{
async GetVaultsByProfileId(profileId){
  AppState.vaults = []
  const res = await api.get(`api/profiles/${profileId}/vaults`)
  logger.log('Vaults by profileId res', res.data)
AppState.vaults = res.data.map(v => new VaultModel(v))
}
async GetProfile(profileId){
  AppState.activeProfile ={}
  const res = await api.get(`api/profiles/${profileId}`)
  logger.log("Active profile res", res.data)
  AppState.activeProfile = new ProfileModel(res.data)
}
async GetKeepsByProfileId(profileId){
  AppState.keeps = []
  const res = await api.get(`api/profiles/${profileId}/keeps`)
  logger.log("profile keeps res", res.data)
  AppState.keeps = res.data.map(k => new KeepModel(k))
}
}

export const profilesService = new ProfilesService()