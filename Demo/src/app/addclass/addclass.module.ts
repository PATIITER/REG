import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddclassPageRoutingModule } from './addclass-routing.module';

import { AddclassPage } from './addclass.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule,
    AddclassPageRoutingModule
  ],
  declarations: [AddclassPage]
})
export class AddclassPageModule {}
