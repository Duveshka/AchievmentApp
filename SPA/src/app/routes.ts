import {Routes} from '@angular/router';
import { AchievmentsComponent } from './achievments/achievments.component';
import { EducationComponent } from './education/education.component';
import { HomeComponent } from './home/home.component';
import { InfoComponent } from './Info/Info.component';
import { NewAchComponent } from './newAch/newAch.component';
import { NewPortfolioComponent } from './newPortfolio/newPortfolio.component';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { PortfolioCardComponent } from './portfolioCard/portfolioCard.component';
import { RegisterComponent } from './register/register.component';
import { SportComponent } from './sport/sport.component';
import { VolunteeringComponent } from './volunteering/volunteering.component';
import { WorkComponent } from './work/work.component';


export const appRoutes: Routes = [
         { path: '', component: HomeComponent },
         {
           path: '',
           runGuardsAndResolvers: 'always',
           children: [
            { path: 'Register', component: RegisterComponent },
            { path: 'Achievments', component: AchievmentsComponent },
            { path: 'Sport', component: SportComponent },
            { path: 'Work', component: WorkComponent },
            { path: 'Education', component: EducationComponent },
            { path: 'Volunteering', component: VolunteeringComponent },
            { path: 'NewAch', component: NewAchComponent },
            { path: 'Info', component: InfoComponent },
            { path: 'Portfolio', component: PortfolioComponent },
            { path: 'NewPortfolio', component: NewPortfolioComponent },
            { path: 'PortfolioCard', component: PortfolioCardComponent }
           ]
         },
       ];