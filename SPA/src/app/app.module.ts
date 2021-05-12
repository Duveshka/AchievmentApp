import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';
import { RegisterComponent } from './register/register.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { AchievmentsComponent } from './achievments/achievments.component';
import { SportComponent } from './sport/sport.component';
import { WorkComponent } from './work/work.component';
import { VolunteeringComponent } from './volunteering/volunteering.component';
import { EducationComponent } from './education/education.component';
import { NewAchComponent } from './newAch/newAch.component';
import { InfoComponent } from './Info/Info.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { NewPortfolioComponent } from './newPortfolio/newPortfolio.component';
import { PortfolioCardComponent } from './portfolioCard/portfolioCard.component';

@NgModule({
  declarations: [																	
    AppComponent,
    HeaderComponent,
    RegisterComponent,
      AchievmentsComponent,
      SportComponent,
      WorkComponent,
      VolunteeringComponent,
      EducationComponent,
      NewAchComponent,
      InfoComponent,
      PortfolioComponent,
      NewPortfolioComponent,
      PortfolioCardComponent
   ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
