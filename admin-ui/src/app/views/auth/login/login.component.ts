import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AdminApiAuthApiClient, Login_Request, LoginResult } from '../../../api/admin-api.service.generated';
import { AlertService } from '../../../shared/services/alert.service';
import { Router } from '@angular/router';
import { UrlConstants } from '../../../shared/contant/url.constant';
import { TokenStorageService } from '../../../shared/services/token-storage.service';
import { Subject, take, takeUntil } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnDestroy {
  loginForm: FormGroup;
  private ngUnsubscribe = new Subject<void>;
  loading = false;

  constructor(private fb: FormBuilder,
    private authApiClient: AdminApiAuthApiClient,
    private alertService: AlertService,
    private router: Router,
    private tokenService : TokenStorageService
  ) {
    this.loginForm = this.fb.group({
      userName: new FormControl('', Validators.required),
      passWord: new FormControl('', Validators.required)
    })
  }
  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();

  }
  login() {
    this.loading = true;
    var request: Login_Request = new Login_Request({

      userName: this.loginForm.controls['userName'].value,
      passWord: this.loginForm.controls['passWord'].value
    })
    this.authApiClient.login(request)
    .pipe(takeUntil(this.ngUnsubscribe))
    .subscribe({
      next: (res: LoginResult) => {
        //Save token and refesh token
          this.tokenService.saveToken(res.token ?? '');
          this.tokenService.saveRefreshToken(res.refreshToken ?? '');

              //Redirect to dashboard
          this.router.navigate([UrlConstants.HOME]);
      },
      error: (error: any) => {
        console.log(error);
        this.alertService.showError('Login invalid')
        this.loading = false;
      },
    });
  }
}
