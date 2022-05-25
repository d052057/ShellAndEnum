import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  public msg!: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any>(baseUrl + 'Shell/get')
      .subscribe((data: any) => {
        this.msg = (data);
      })
  }
}
