import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { INavData } from '@coreui/angular';

import { navItems } from './_nav';
import { TokenStorageService } from './../../shared/services/token-storage.service';
import { UrlConstants } from './../../shared/contant/url.constant';

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
  styleUrls: ['./default-layout.component.scss'],
})
export class DefaultLayoutComponent implements OnInit {
  public navItems: INavData[] = [];

  constructor(
    private tokenService: TokenStorageService,
    private router: Router
  ) {}

 ngOnInit(): void {
  const user = this.tokenService.getUser();
  if (!user) {
    this.router.navigate([UrlConstants.LOGIN]);
    return;
  }

  let permissions: string[] = [];
  try {
    permissions = JSON.parse(user.permissions ?? '[]');
  } catch {
    permissions = [];
  }

  this.navItems = navItems.map(item => {
    if (!item.children) return item;

    return {
      ...item,
      children: item.children.map(child => {
        const policyName = child.attributes?.['policyName'];
        const hidden = !!policyName && !permissions.includes(policyName);

        console.log(
          `Menu: ${child.name}`,
          'Policy:', policyName,
          'HasPermission:', permissions.includes(policyName)
        );

        return {
          ...child,
          class: hidden ? 'd-none' : '' 
        };
      })
    };
  });
}


}
