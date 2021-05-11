import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'AchievmentApp';
  achievments: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getAchievments();
  }

  getAchievments() {
    this.http.get('https://localhost:5001/api/').subscribe( response => {
      this.achievments = response;
    }, error => {
      console.log(error);
    })
  }
}
