import { AppState } from "../AppState"
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
  AppState.keeps = new KeepModel(res.data)
}
}

export const keepsService = new KeepsService()