import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Eventmanager14905Component } from './eventmanager14905.component';
import { MatCardModule } from '@angular/material/card';
import { DetailsComponent } from './details/details.component';
import { MatFormFieldModule } from '@angular/material/form-field';

import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateComponent } from './create/create.component';
import { DeleteComponent } from './delete/delete.component';
import { EditComponent } from './edit/edit.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Import BrowserAnimationsModule
import { BrowserModule } from '@angular/platform-browser';
import { MatDatepickerModule } from '@angular/material/datepicker'; // Import MatDatepickerModule
import { MatNativeDateModule } from '@angular/material/core';



@NgModule({
  declarations: [
    Eventmanager14905Component,
    DetailsComponent,
    CreateComponent,
    DeleteComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatButtonModule,
    MatSelectModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BrowserModule,
    MatDatepickerModule,
    MatNativeDateModule

  ],
})
export class Eventmanager14905Module { }
