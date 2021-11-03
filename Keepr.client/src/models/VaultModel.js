export class VaultModel{
  constructor(vaultData){
    this.id = vaultData.id
    this.creatorId = vaultData.creatorId
    this.name = vaultData.name
    this.description = vaultData.description
    this.isPrivate = vaultData.isPrivate
    this.creator = vaultData.creator
  }
}