import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService{
async GetKeeps(){
  const res = await api.get('api/keeps')
  logger.log("Get All Keeps res", res)
}

async GetKeepById(keepId){
  const res = await api.get('api/keeps/' + keepId)
  logger.log("Get keep by id res", res)
}
}

export const keepsService = new KeepsService()