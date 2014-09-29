'''
Created on Nov 5, 2013

@author: matthew.ross
'''

from abc import ABCMeta, abstractmethod
import pygame
import sys

class BouncingBallScreen(object):
    def __init__(self, thisBall, width, height):
        pygame.init()
        self.size = self.width, self.height = width, height
        self.screen = pygame.display.set_mode(self.size)
        self.black = 0, 0, 0
        self.ball = thisBall
        
    def runGame(self):
        while 1:
            for event in pygame.event.get():
                if event.type == pygame.QUIT: 
                    sys.exit()
                if event.type == pygame.KEYDOWN and \
                   event.key == pygame.K_SPACE:
                    self.ball.respondToSpaceBar()                    
                    
            self.screen.fill(self.black)
            self.ball.draw(self.screen)
            pygame.display.flip()
            pygame.time.wait(10)

            
                    
class AbstractBouncingBall(metaclass=ABCMeta):
    '''
    The class is an abstract bouncing ball class
    Students will extend it to make it respond to key presses
    '''
    
    def draw(self, screen):
        self.ballrect = self.ballrect.move(self.speed)
        if self.ballrect.left < 0 or self.ballrect.right > self.rightLimit:
            self.speed[0] = -self.speed[0]
        if self.ballrect.top < 0 or self.ballrect.bottom > self.bottomLimit:
            self.speed[1] = -self.speed[1]
        screen.blit(self.ballSurface, self.ballrect)
        
    
    @abstractmethod
    def respondToSpaceBar(self):
        pass


    def __init__(self, rightLimit, bottomLimit):
        self.ballSurface = pygame.image.load("ball.gif")
        self.ballrect = self.ballSurface.get_rect()
        self.speed = [1,1]
        self.bottomLimit = bottomLimit
        self.rightLimit = rightLimit
        
class BouncingBallUnresponsive(AbstractBouncingBall):
    
    def respondToSpaceBar(self):
        pass
    
class BouncingBallVanishing(AbstractBouncingBall):
    def __init__(self, rightLimit, bottomLimit):
        super().__init__(rightLimit, bottomLimit)
        self.visible = True
        
    def respondToSpaceBar(self):
        pass
            
    def draw(self, screen):
        pass

class BouncingBallJitter(AbstractBouncingBall):
        
    def respondToSpaceBar(self):
        pass
        

    
if __name__=="__main__":
    myBall = BouncingBallUnresponsive(320, 240)
    # myBall = BouncingBallVanishing(320, 240)
    # myBall = BouncingBallJitter(320, 240)
    myScreen = BouncingBallScreen(myBall, 320, 240)
    myScreen.runGame()

