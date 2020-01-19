import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {datauser} from 'src/app/Models/user';
import {dataTeacher} from 'src/app/Models/teacher';
import { dataclass } from './Models/class';




@Injectable({
  providedIn: 'root'
})
export class CallApiService {
  public static host: string = "https://localhost:5001/api/";

  constructor(public Http:HttpClient) { }
    
  public GetgetdatauserAll() {
    return this.Http.get<datauser>(CallApiService.host + 'user/GetgetdatauserAll');
    
  }
  public GetdatauserbyId(Id:string){
   return this.Http.get<datauser>(CallApiService.host+'user/GetdatauserbyId/'+ Id);

}
public addUser(data:datauser) {
  console.log(data);
  return this.Http.post<datauser>(CallApiService.host + 'user/adduser/', data );
}




public GetAllTeacher() {
  
  return this.Http.get<dataTeacher>(CallApiService.host + 'Teacher/GetTeacherAll');
}
public GetAllClass(){

  return this.Http.get<dataclass>(CallApiService.host + 'Class/GetClassAll');
}
public GetdataTeacherId(Id:string){
  return this.Http.get<dataTeacher>(CallApiService.host+'Teacher/GetTeacherId/'+ Id);
}
public AddNewTeacher(data:dataTeacher){
  console.log(data);
  return this.Http.post<dataTeacher>(CallApiService.host + 'Teacher/AddTeacher/', data );
}


}
