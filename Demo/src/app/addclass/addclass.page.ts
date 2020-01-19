import { Component, OnInit } from '@angular/core';
import { CallApiService } from '../call-api.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { AlertController } from '@ionic/angular';
import { Router } from '@angular/router';
import { dataclass } from '../Models/class';
import { dataTeacher } from '../Models/teacher';

@Component({
  selector: 'app-addclass',
  templateUrl: './addclass.page.html',
  styleUrls: ['./addclass.page.scss'],
})
export class AddclassPage implements OnInit {
  dataTeacher:dataTeacher;
dataClass:any[] = ['idClass','nameClass'];
  nameClass:string;
  data:FormGroup;
  dataclassx:dataclass;

  constructor(public callapi:CallApiService,public builder:FormBuilder,public alertController:AlertController,public router : Router) {
    this.data = this.builder.group({
      'idTeacher':[null,Validators.required],
      'nameTeacher':[null,Validators.required],
      'class':[this.dataClass.values,Validators.required],
      'username':[null,Validators.required],
      'password':[null,Validators.required]
    });
   }

  ngOnInit() {
    this.getAllClass();
  }


  getAllClass() {
    this.callapi.GetAllClass().subscribe(it =>{
      this.dataClass[0] = it;
      console.log(this.dataClass);
    });
  }


  addclass(){

    console.log(this.data.value);
    this.dataTeacher = this.data.value;
    console.log(this.dataTeacher);

    

    console.log(this.data.value.class);
    console.log(this.dataClass.values);
   

    
    

    
    // this.callapi.AddNewTeacher(this.dataTeacher).subscribe(it =>{
    //   console.log(it); 
    //    this.router.navigate(['/teacher']);
    // });

  }
}
