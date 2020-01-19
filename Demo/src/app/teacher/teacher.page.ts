import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallApiService } from '../call-api.service';
import { dataTeacher } from '../models/teacher';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.page.html',
  styleUrls: ['./teacher.page.scss'],
})
export class TeacherPage implements OnInit {

  dataTeacher:dataTeacher;
  getid:string;
  teacherbyid:dataTeacher;

  constructor(public callapi: CallApiService, public router: Router,public activated:ActivatedRoute) {
    this.getid = activated.snapshot.paramMap.get('_id');
    console.log(this.getid);
    callapi.GetdataTeacherId(this.getid).subscribe(it =>{
      // console.log(it);
      this.teacherbyid = it;
      console.log(this.teacherbyid);

      console.log(this.teacherbyid.class);
      
    });
   }

  ngOnInit() {
    this.getAllTeacher();
  }


  getAllTeacher() {
    this.callapi.GetAllTeacher().subscribe(it =>{
      this.dataTeacher = it;
      console.log(this.dataTeacher);
    });
  }
  

  GoPageAddClass(){

    this.router.navigate(['/addclass'])
  }
}
