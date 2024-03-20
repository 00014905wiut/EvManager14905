import { Routes } from '@angular/router';
// import { HomeComponent } from './eventmanager14905/home/home.component';
import { CreateComponent } from './eventmanager14905/create/create.component';
import { EditComponent } from './eventmanager14905/edit/edit.component';
import { DeleteComponent } from './eventmanager14905/delete/delete.component';
import { DetailsComponent } from './eventmanager14905/details/details.component';

export const routes: Routes = [
    {
        path: 'create',
        component: CreateComponent
    },
    {
        path: 'edit/:id',
        component: EditComponent
    },
    {
        path: 'delete/:id',
        component: DeleteComponent
    },
    {
        path: 'details/:id',
        component: DetailsComponent
    }
];
