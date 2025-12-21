import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AdminApiAuthApiClient, Login_Request, LoginResult } from '../../../api/admin-api.service.generated';
import { AlertService } from '../../../shared/services/alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;
  constructor(private fb: FormBuilder,
    private authApiClient: AdminApiAuthApiClient,
    private alertService: AlertService,
      private router: Router
  ) {
    this.loginForm = this.fb.group({
      userName: new FormControl('', Validators.required),
      passWord: new FormControl('', Validators.required)
    })
  }
  login() {
    var request: Login_Request = new Login_Request({

      userName: this.loginForm.controls['userName'].value,
      passWord: this.loginForm.controls['passWord'].value
    })
    this.authApiClient.login(request).subscribe({
      next: (res: LoginResult) => {
        //Save token and refesh token

              //Redirect to dashboard
          this.router.navigate(['/dashboard']);
      },
      error: (error: any) => {
        console.log(error);
        this.alertService.showError('Login invalid')
      },
    });
  }
}
