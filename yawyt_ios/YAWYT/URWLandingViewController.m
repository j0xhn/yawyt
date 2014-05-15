//
//  URWLandingViewController.m
//  YAWYT
//
//  Created by Anthony Hart on 7/18/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import "URWLandingViewController.h"
#import "NotificationName.h"
#import "TweetModel.h"
#import "TweetGrabber.h"

@interface URWLandingViewController ()

@end

@implementation URWLandingViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
	
	self.currScore = 0;
	[self populateUiWithRandomValues];
}

-(void)populateUiWithRandomValues{
	//TODO: Replace these mock calls with calls to real methods later (right now, we just want to make sure that
	//		we can display and manage data)
	
	//Get a random tweet
	self.tweet = [TweetGrabber MOCK_getRandomTweet:self.tweet];
	
	//Display the text of the tweet in the UI
	self.lblTweetContent.text = self.tweet.text;
	
	//Get some random user names
	self.userFullNames = [TweetGrabber MOCK_getRandomUserFullNames];
	
	//Display the user names in the UI
	[self populateTweeterItemNames];
}

-(void)populateTweeterItemNames{
	//This method assumes that the array has already been populated
	self.btnTweeter1Name.titleLabel.text = self.userFullNames[0];
	self.btnTweeter2Name.titleLabel.text = self.userFullNames[1];
	self.btnTweeter3Name.titleLabel.text = self.userFullNames[2];
	self.btnTweeter4Name.titleLabel.text = self.userFullNames[3];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated. 
}

-(IBAction)btnMenu_touchUpInside{
	[[NSNotificationCenter defaultCenter] postNotificationName:NOTIFICATION_NAME_SHOW_MENU object:nil];
}

-(IBAction)btnSignOut_touchUpInside{
	//TODO: implement
	
	[[[UIAlertView alloc]
	  initWithTitle:@"PLACEHOLDER"
	  message:@"Not yet implemented: btnSignOut_touchUpInside"
	  delegate:nil
	  cancelButtonTitle:@"OK"
	  otherButtonTitles:nil
	] show];
	
	//TODO: Clear any state that shows this user as signed in
	
	//Go back to the sign-in screen
	[[NSNotificationCenter defaultCenter] postNotificationName:NOTIFICATION_NAME_NAVIGATE_TO_SIGN_IN_SCREEN object:nil];
}

-(IBAction)btnNext_touchUpInside{
	[self populateUiWithRandomValues];
}

-(IBAction)tweeterItem_touchUpInside:(id)sender{
	//TODO: implement
	
	//This is an attempt to fix the problem of the disappearing button name
	[self populateTweeterItemNames];
	
	//The tags of the sender should be 1-4 - grouped per set of UI controls for each tweeter item
	//in the list of answers
	int tag = [sender tag];
	
	//Determine which tweeter item this is for
	NSString *selectedUserFullName = self.userFullNames[tag - 1];
	
	//TODO: Determine whether or not this tweeter item is the correct selection
	if([self.tweet.userFullName isEqualToString:selectedUserFullName]){
		//The correct answer has been chosen
		[[[UIAlertView alloc]
		  initWithTitle:@"PLACEHOLDER"
		  message:@"Not yet implemented: CORRECT ANSWER"
		  delegate:nil
		  cancelButtonTitle:@"OK"
		  otherButtonTitles:nil
		] show];
		
		//Increment the score
		self.currScore++;
		self.lblYourScore.text = [@"" stringByAppendingFormat:@"%d", self.currScore];
	}
	else{
		//An incorrect answer has been chosen
		[[[UIAlertView alloc]
		  initWithTitle:@"PLACEHOLDER"
		  message:@"Not yet implemented: INCORRECT ANSWER"
		  delegate:nil
		  cancelButtonTitle:@"OK"
		  otherButtonTitles:nil
		] show];
	}
}

@end
