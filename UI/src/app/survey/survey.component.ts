import { Component, OnInit } from '@angular/core';
import { GeofencingService } from '../geofencing/geofencing.service';



@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {
    questionGroup: string;
    questionGroupModel: QuestionGroupModel;
    lang = 1;

    constructor(
    public geofencingService: GeofencingService,
    ) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.geofencingService.getQuestionGroup(1, this.lang).subscribe( data => {
      this.questionGroupModel = data;
    });
  }
}

export class QuestionGroupModel {
  groupDescription: string;
  questions: QuestionsModel[];
}

export class QuestionsModel {
  questionCode: string;
  questionText: string;
  rtl: boolean;
}
