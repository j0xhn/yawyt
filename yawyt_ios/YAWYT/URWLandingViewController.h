//
//  URWLandingViewController.h
//  YAWYT
//
//  Created by Anthony Hart on 7/18/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "TweetModel.h"

@interface URWLandingViewController : UIViewController

@property (strong, nonatomic) IBOutlet UIButton *btnMenu;
@property (strong, nonatomic) IBOutlet UIButton *btnSignOut;

@property (strong, nonatomic) IBOutlet UILabel *lblTweetContent;
@property (strong, nonatomic) IBOutlet UILabel *lblYourScore;
@property (strong, nonatomic) IBOutlet UIButton *btnNext;

@property (strong, nonatomic) IBOutlet UIButton *btnTweeter1Background;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter1Image;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter1Name;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter1Points;

@property (strong, nonatomic) IBOutlet UIButton *btnTweeter2Background;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter2Image;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter2Name;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter2Points;

@property (strong, nonatomic) IBOutlet UIButton *btnTweeter3Background;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter3Image;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter3Name;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter3Points;

@property (strong, nonatomic) IBOutlet UIButton *btnTweeter4Background;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter4Image;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter4Name;
@property (strong, nonatomic) IBOutlet UIButton *btnTweeter4Points;

@property (strong, nonatomic) NSMutableArray *userFullNames;
@property (strong, nonatomic) TweetModel *tweet;
@property int currScore;

-(IBAction)btnMenu_touchUpInside;
-(IBAction)btnSignOut_touchUpInside;

-(IBAction)btnNext_touchUpInside;
-(IBAction)tweeterItem_touchUpInside:(id)sender;

@end
