import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { ButtonModule, CardModule, FormModule, GridModule } from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { ContentRoutingModule } from './content-routing.module';
import { PostComponent } from './posts/post.component';


@NgModule({
  declarations: [
    PostComponent
  ],
  imports: [
    CommonModule,
    ContentRoutingModule,
    CardModule,
    ButtonModule,
    GridModule,
    IconModule,
    FormModule
  ]
})
export class ContentModule {
}
