import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    constructor(private data: DataService, private router: Router) { }

    errorMessage = '';

    public creds = {
        username: '',
        password: ''
    };

  ngOnInit(): void {
  }

    onLogin() {
        this.data.login(this.creds).subscribe(success => {
            if (success) {
                if (this.data.order.items.length === 0) {
                    this.router.navigate(["/"]);
                } else {
                    this.router.navigate(["checkout"]);
                }
            }
        }, err => this.errorMessage ='Failed to login');
    }

}
