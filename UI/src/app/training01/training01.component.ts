import { Component, OnInit, Directive } from '@angular/core';

@Component({
  selector: 'app-training01',
  templateUrl: './training01.component.html',
  styleUrls: ['./training01.component.css']
})
export class Training01Component implements OnInit {
  formdata: any = { userName: "", organisation: "" };

  constructor() { }

  ngOnInit() {
  }

}

