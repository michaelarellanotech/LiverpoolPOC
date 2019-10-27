import { Component, OnInit, ContentChild } from '@angular/core';
import { Card } from 'primeng/card';
import { Button } from 'primeng/button';
import { fromEvent } from 'rxjs';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent implements OnInit {

  @ContentChild("projectedCardComponent") projectedContent: Card;
  @ContentChild("projectedButton") projectedButton: Button;
  
  constructor() { 
  }

  ngOnInit() 
  {
    this.projectedButton.onClick.subscribe((event) => console.log('got clicked', event));
  }


  ngAfterContentInit() {
    console.log("projectedContent", this.projectedContent);
    this.projectedContent.header = "I Just Changed this text using @ContentChild";
  }

}
