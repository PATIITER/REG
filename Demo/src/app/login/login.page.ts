import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {dataTeacher} from 'src/app/Models/teacher';


@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  data:FormGroup;

  datauser:dataTeacher;

  constructor(public router : Router,public builder:FormBuilder) {

    this.data = this.builder.group({
      'username':[null,Validators.required],
      'password':[null,Validators.required]
    });

    
   }

  ngOnInit() {
  }

  gopage(id){
    
    
    this.router.navigate(['/teacher',{_id:id}])
    console.log(this.data.value);
    this.datauser= this.data.value;
    console.log(this.datauser);
    


    
  }

  

}
