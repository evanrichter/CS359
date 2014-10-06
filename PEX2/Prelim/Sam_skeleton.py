class GameWindow():
  currStage
  nextStage
  def pickNextStage():
    pass

class Stage():
  fixedObstacleList
  enemies

class Obstacle():
  fixed
  xLoc
  yLoc
  shape

class EnemyInterface():
  health
  def move():
    pass
  def die():
    pass

class DumbCircle(EnemyInterface):
  shape
  def move():
    pass
  def die():
    pass

class SmartCircle(DumbCircle):
  def move():
    pass

class DumbTriangle(EnemyInterface):
  shape
  def move():
    pass
  def die():
    pass

class SmartTriangle(DumbTriangle):
  def move():
    pass

class Boss(EnemyInterface):
  shape
  def move():
    pass
  def die():
    pass

class Sam():
  health
  powerup
  def roll():
    pass
  def jump():
    pass
  def die():
    pass
