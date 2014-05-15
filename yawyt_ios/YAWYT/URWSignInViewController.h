//
//  URWSignInViewController.h
//  YAWYT
//
//  Created by Anthony Hart on 7/18/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Social/Social.h> //For Twitter integration

@interface URWSignInViewController : UIViewController

@property (strong, nonatomic) IBOutlet UIButton *btnMenu;

@property (strong, nonatomic) IBOutlet UIButton *btnSignInWithTwitter;
@property (strong, nonatomic) IBOutlet UIButton *btnSignIn;
@property (strong, nonatomic) IBOutlet UITextField *txtUserName;
@property (strong, nonatomic) IBOutlet UITextField *txtPassword;

-(IBAction)btnMenu_touchUpInside;
-(IBAction)btnSignInWithTwitter_touchUpInside;
-(IBAction)btnSignIn_touchUpInside;

//For dealing with keyboard hiding
-(IBAction)textField_didEndOnExit:(id)sender;
-(IBAction)view_backgroundTap:(id)sender;

@end
