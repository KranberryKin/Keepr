export class KeepModel{
  constructor(keepData){
    this.id = keepData.id
    this.creatorId = keepData.creatorId
    this.name = keepData.name
    this.description = keepData.description
    this.img = keepData.img
    this.views = keepData.views
    this.shares = keepData.shares
    this.keeps = keepData.keeps
    this.creator = keepData.creator
  }
}