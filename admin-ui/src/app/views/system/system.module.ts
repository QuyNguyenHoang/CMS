import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SystemRoutingModule } from './system-routing.module';
import { UserComponent } from './users/user.component';
import { RoleComponent } from './roles/role.component';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { BlockUIModule } from 'primeng/blockui';
import { PaginatorModule } from 'primeng/paginator';
import { PanelModule } from 'primeng/panel';
import { CheckboxModule } from 'primeng/checkbox';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { RoleDetailComponent } from './roles/role-detail.component';
import { CmsSharedModule } from '../../shared/modules/cms-shared.module';
import { KeyFilterModule } from 'primeng/keyfilter';
import { PermissionGrantComponent } from './roles/permission-grant.component';
import { BadgeModule } from 'primeng/badge';
import { UserDetailComponent } from './users/user-detail.component';
import { SetPasswordComponent } from './users/set-password.component';
import { RoleAssignComponent } from './users/role-assign.component';
import { ChangeEmailComponent } from './users/change-email.component';
import { PickListModule } from 'primeng/picklist';
import { ImageModule } from 'primeng/image';
import { InputNumberModule } from 'primeng/inputnumber';




@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,

    SystemRoutingModule,

    // PrimeNG
    TableModule,
    PanelModule,
    PaginatorModule,
    BlockUIModule,
    ProgressSpinnerModule,
    CheckboxModule,
    ButtonModule,
    InputTextModule,
    InputNumberModule,
    BadgeModule,
    ImageModule,
    KeyFilterModule,
    PickListModule,

    // Shared
    CmsSharedModule
  ],
  declarations: [
    UserComponent,
    UserDetailComponent,
    SetPasswordComponent,
    ChangeEmailComponent,
    RoleAssignComponent,

    RoleComponent,
    RoleDetailComponent,
    PermissionGrantComponent
  ]
})


export class SystemModule { }