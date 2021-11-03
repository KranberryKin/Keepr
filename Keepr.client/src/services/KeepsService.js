import { AppState } from "../AppState"
import { KeepModel } from "../models/KeepModel"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService{
async GetKeeps(){
  const res = await api.get('api/keeps')
  logger.log("Get All Keeps res", res)
  AppState.keeps = res.data.map(k => new KeepModel(k))
}

async GetKeepById(keepId){
  const res = await api.get('api/keeps/' + keepId)
  logger.log("Get keep by id res", res)
  AppState.activeKeep = new KeepModel(res.data)
}
async CreateKeep(keepData){
  const res = await api.post('api/keeps', keepData)
  logger.log("Create Keep res", res)
  AppState.keeps = [new KeepModel(res.data), ...AppState.keeps]
}
async EditKeep(keepData){
  const res = await api.put('api/keeps/' + keepData.id, keepData)
  logger.log("Edit Keep res", res)
  let keepIndex = AppState.keeps.findIndex(k => k.id === keepData.id)
  AppState.keeps.splice(keepIndex, 1, new KeepModel(res.data))
}
async DeleteKeep(keepId){
  const res = await api.delete('api/keeps/' + keepId)
  logger.log("Delete Keep Res", res)
  let keepIndex = AppState.keeps.findIndex(k => k.id === keepId)
  AppState.keeps.splice(keepIndex, 1)
}
}

export const keepsService = new KeepsService()