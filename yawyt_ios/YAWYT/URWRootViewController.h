//
//  URWRootViewController.h
//  YAWYT
//
//  Created by Anthony Hart on 7/18/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import <UIKit/UIKit.h>

@class URWSignInViewController;
@class URWLandingViewController;

@interface URWRootViewController : UIViewController

@property (strong, nonatomic) URWSignInViewController *signInViewController;
@property (strong, nonatomic) URWLandingViewController *landingViewController;

@end
