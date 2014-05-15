//
//  URWSignInViewController.m
//  YAWYT
//
//  Created by Anthony Hart on 7/18/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import "URWSignInViewController.h"
#import "Globals.h"
#import "NotificationName.h"

@interface URWSignInViewController ()

@end

@implementation URWSignInViewController

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
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(IBAction)btnSignIn_touchUpInside{
	//TODO: implement
	
	//TODO: If credentials are valid, navigate to the landing screen
	NSString *userName = [self.txtUserName text];
	NSString *password = [self.txtPassword text];
	
	if(![userName isEqualToString:@""] && ![password isEqualToString:@""]){
		[[[UIAlertView alloc]
		  initWithTitle:@"PLACEHOLDER"
		  message:[@"" stringByAppendingFormat:@"Not yet implemented: btnSignIn_touchUpInside | userName = %@, password = %@", userName, password]
		  delegate:nil
		  cancelButtonTitle:@"OK"
		  otherButtonTitles:nil
		] show];
		
		//Persist the credentials
		[Globals setCurrUserName:userName andPassword:password];
		
		//TODO: Remove after testing...just pretend the credentials are good for now
		[self navigateToLandingScreen];
	}
	else{
		//Invalid credentials
		[[[UIAlertView alloc]
		  initWithTitle:@"PLACEHOLDER"
		  message:[@"" stringByAppendingFormat:@"Not yet implemented: btnSignIn_touchUpInside | INVALID CREDENTIALS | userName = %@, password = %@", userName, password]
		  delegate:nil
		  cancelButtonTitle:@"OK"
		  otherButtonTitles:nil
		] show];
	}
}

-(void)navigateToLandingScreen{
	[[NSNotificationCenter defaultCenter] postNotificationName:NOTIFICATION_NAME_NAVIGATE_TO_LANDING_SCREEN object:nil];
}

-(IBAction)btnMenu_touchUpInside{
	[[NSNotificationCenter defaultCenter] postNotificationName:NOTIFICATION_NAME_SHOW_MENU object:nil];
}

-(IBAction)btnSignInWithTwitter_touchUpInside{
	//TODO: implement
	
	
	
	if([SLComposeViewController isAvailableForServiceType:SLServiceTypeTwitter]){
		SLComposeViewController *twitterComposer = [SLComposeViewController composeViewControllerForServiceType:SLServiceTypeTwitter];
		
		//TODO: rat
		//Tweet something
		[twitterComposer setInitialText:@"This is a test tweet."];
		[self presentViewController:twitterComposer animated:YES completion:nil];
	}
	else{
		[[[UIAlertView alloc]
		  initWithTitle:@"ERROR"
		  message:@"Twitter is inaccessible."
		  delegate:nil
		  cancelButtonTitle:@"OK"
		  otherButtonTitles:nil
		] show];
	}
	
	
	
	[[[UIAlertView alloc]
	  initWithTitle:@"PLACEHOLDER"
	  message:@"Not yet implemented: btnSignInWithTwitter_touchUpInside"
	  delegate:nil
	  cancelButtonTitle:@"OK"
	  otherButtonTitles:nil
	] show];
}

-(IBAction)textField_didEndOnExit:(id)sender{
	//Resign as first responder so the keyboard will disappear
	[sender resignFirstResponder];
}

-(IBAction)view_backgroundTap:(id)sender{
	//Resign as first responder so the keyboard will disappear
	[self.txtUserName resignFirstResponder];
	[self.txtPassword resignFirstResponder];
}

@end
