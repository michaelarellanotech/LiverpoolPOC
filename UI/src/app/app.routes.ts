import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { DashboardDemoComponent } from './demo/view/dashboarddemo.component';
import { SampleDemoComponent } from './demo/view/sampledemo.component';
import { FormsDemoComponent } from './demo/view/formsdemo.component';
import { DataDemoComponent } from './demo/view/datademo.component';
import { PanelsDemoComponent } from './demo/view/panelsdemo.component';
import { OverlaysDemoComponent } from './demo/view/overlaysdemo.component';
import { MenusDemoComponent } from './demo/view/menusdemo.component';
import { MessagesDemoComponent } from './demo/view/messagesdemo.component';
import { MiscDemoComponent } from './demo/view/miscdemo.component';
import { EmptyDemoComponent } from './demo/view/emptydemo.component';
import { ChartsDemoComponent } from './demo/view/chartsdemo.component';
import { FileDemoComponent } from './demo/view/filedemo.component';
import { DocumentationComponent } from './demo/view/documentation.component';
import { AppMainComponent } from './app.main.component';
import { AppNotfoundComponent } from './pages/app.notfound.component';
import { AppErrorComponent } from './pages/app.error.component';
import { AppAccessdeniedComponent } from './pages/app.accessdenied.component';
import { AppLoginComponent } from './pages/app.login.component';
import { GeofencingComponent } from './geofencing/geofencing.component';
import { AddressearchComponent } from './addressearch/addressearch.component';
import { Training01Component } from './training01/training01.component';
import { SurveyComponent } from './survey/survey.component';

export const routes: Routes = [
    { path: '', component: AppMainComponent,
        children: [
            { path: '', component: DashboardDemoComponent },
            { path: 'sample', component: SampleDemoComponent },
            { path: 'forms', component: FormsDemoComponent },
            { path: 'data', component: DataDemoComponent },
            { path: 'panels', component: PanelsDemoComponent },
            { path: 'overlays', component: OverlaysDemoComponent },
            { path: 'menus', component: MenusDemoComponent },
            { path: 'messages', component: MessagesDemoComponent },
            { path: 'misc', component: MiscDemoComponent },
            { path: 'empty', component: EmptyDemoComponent },
            { path: 'charts', component: ChartsDemoComponent },
            { path: 'file', component: FileDemoComponent },
            { path: 'documentation', component: DocumentationComponent },
            { path: 'geofencing', component: GeofencingComponent },
            { path: 'addresssearch', component: AddressearchComponent },
            { path: 'survey', component: SurveyComponent },
            { path: 'training01', component: Training01Component }
        ]
    },
    {path: 'error', component: AppErrorComponent},
    {path: 'accessdenied', component: AppAccessdeniedComponent},
    {path: '404', component: AppNotfoundComponent},
    {path: 'login', component: AppLoginComponent},
    {path: '**', redirectTo: '/404'},

];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'});
