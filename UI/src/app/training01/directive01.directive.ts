import { Directive, HostBinding, ElementRef, Renderer2, HostListener } from '@angular/core';

@Directive({
  selector: '[appDirective01]'
})
export class Directive01Directive {

  @HostBinding('style.color') color: string;
  
  constructor(
    private el: ElementRef,
    private renderer2: Renderer2
  ) 
  {
    this.color = "red";
    console.log('el', this.el);
    console.log('renderer2', this.renderer2);
    (<HTMLElement>this.el.nativeElement).style.backgroundColor = "pink";

    (this.el.nativeElement as HTMLElement).style.fontSize = "20px"; 
  }

  @HostListener('keydown') onKeyDown() {
    console.log('keydown');
  }

}
