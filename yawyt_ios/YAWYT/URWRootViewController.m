//
//  URWRootViewController.m
//  yawyt3
//
//  Created by Anthony Hart on 7/18/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import "URWRootViewController.h"
#import "URWSignInViewController.h"
#import "URWLandingViewController.h"
#import "NibName.h"
#import "NotificationName.h"

//@interface URWRootViewController ()

//@end

@implementation URWRootViewController

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
    
	//Register notification listeners
	[[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleNotification_navigateToLandingScreen:) name:NOTIFICATION_NAME_NAVIGATE_TO_LANDING_SCREEN object:nil];
	[[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleNotification_navigateToSignInScreen:) name:NOTIFICATION_NAME_NAVIGATE_TO_SIGN_IN_SCREEN object:nil];
	[[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleNotification_showMenu:) name:NOTIFICATION_NAME_SHOW_MENU object:nil];
	
	//Load up the sign-in view as the default
	self.signInViewController = [[URWSignInViewController alloc] initWithNibName:NIB_NAME_SIGN_IN_VIEW bundle:nil];
	[self.view insertSubview:self.signInViewController.view atIndex:0];
}

-(void)viewDidUnload{
	//Unregister notification listeners
	[[NSNotificationCenter defaultCenter] removeObserver:self name:NOTIFICATION_NAME_NAVIGATE_TO_LANDING_SCREEN object:nil];
	[[NSNotificationCenter defaultCenter] removeObserver:self name:NOTIFICATION_NAME_NAVIGATE_TO_SIGN_IN_SCREEN object:nil];
	[[NSNotificationCenter defaultCenter] removeObserver:self name:NOTIFICATION_NAME_SHOW_MENU object:nil];
	
	[super viewDidUnload];
}

-(void)handleNotification_navigateToLandingScreen:(NSNotification *)notification{
	//Remove all the subviews to start out with a clean slate
	[self.view.subviews makeObjectsPerformSelector:@selector(removeFromSuperview)];
	
	//Navigate to the target screen
	if(self.landingViewController == nil) self.landingViewController = [[URWLandingViewController alloc] initWithNibName:NIB_NAME_LANDING_VIEW bundle:nil];
	[self.view insertSubview:self.landingViewController.view atIndex:0];
}

-(void)handleNotification_navigateToSignInScreen:(NSNotification *)notification{
	//Remove all the subviews to start out with a clean slate
	[self.view.subviews makeObjectsPerformSelector:@selector(removeFromSuperview)];
	
	//Navigate to the target screen
	if(self.signInViewController == nil) self.signInViewController = [[URWSignInViewController alloc] initWithNibName:NIB_NAME_SIGN_IN_VIEW bundle:nil];
	[self.view insertSubview:self.signInViewController.view atIndex:0];
}

-(void)handleNotification_showMenu:(NSNotification *)notification{
	//TODO: implement
	
	[[[UIAlertView alloc]
	  initWithTitle:@"PLACEHOLDER"
	  message:@"Not yet implemented: handleNotification_showMenu"
	  delegate:nil
	  cancelButtonTitle:@"OK"
	  otherButtonTitles:nil
	] show];
}

/*
-(void)dealloc{
	//Clean up notification listeners - just in case
	[[NSNotificationCenter defaultCenter] removeObserver:self];
	
	[super dealloc];
}
*/
 
- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    
	//Release resources that aren't in use
	/*
	if(self.signInViewController.view.superview == nil){
		self.signInViewController = nil;
	}
	*/
}

@end
