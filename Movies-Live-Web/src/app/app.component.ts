import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Movies-Live-Web';
  websiteMode:string='light';

  constructor(private titleService:Title, private route: ActivatedRoute){
    this.titleService.setTitle(this.route.snapshot.data['title']);
  }

  ngOnInit(){
    var today = new Date()
    var curHr = today.getHours()

    if (curHr < 12) {
      this.websiteMode = 'light';
    } else if (curHr < 18) {
      this.websiteMode = 'light';
    } else {
      this.websiteMode = 'dark';
    }
  }
}
