import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { ButtonModule, CardModule, FormModule, GridModule } from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { SystemRoutingModule } from './system-routing.module';
import { UserComponent } from './users/user.component';

@NgModule({
  declarations: [
    UserComponent
  ],
  imports: [
    CommonModule,
    SystemRoutingModule,
    CardModule,
    ButtonModule,
    GridModule,
    IconModule,
    FormModule
  ]
})
export class SystemModule {
}
