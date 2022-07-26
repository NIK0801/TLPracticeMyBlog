export interface ICategory {
  id : number;
  title : string;
}
export interface IPost {
  id : number;
  title : string;
  content : string;
  isPublished : number;
  categoryId : number;
}
export interface ITag {
  id : number;
  title : string;
}