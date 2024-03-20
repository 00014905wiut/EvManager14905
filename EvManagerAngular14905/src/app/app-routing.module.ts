import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailsComponent} from './eventmanager14905/details/details.component';

import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { CreateComponent } from './eventmanager14905/create/create.component';
import { EditComponent } from './eventmanager14905/edit/edit.component';
import { DeleteComponent } from './eventmanager14905/delete/delete.component';


// Import EventRating if it's used in any component or service

const routes: Routes = [
  { path: '', redirectTo: 'events', pathMatch: 'full' },
  { path: 'events', component: DetailsComponent },
  { path: 'create', component: CreateComponent },
  { path: 'edit/:id', component: EditComponent },
  { path: 'delete/:id', component: DeleteComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
    MatButtonModule,
    MatSelectModule,
    MatInputModule
],
  exports: [RouterModule]
})
export class AppRoutingModule { }
